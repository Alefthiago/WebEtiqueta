// VARIÁVEIS
const HtmlWebpackPlugin = require('html-webpack-plugin');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const glob = require('glob');
const path = require('path');
// /VARIÁVEIS

const webpackControllerConfig = require('./webpack.controller.config');
const webpackViewConfig = require('./webpack.view.config');

// MAPEAMENTO DOS ARQUIVOS
function groupEntriesByFolder(pattern) {
    let entries = {
        general: {},       // Arquivos gerais
        controllers: {},   // Arquivos gerais do controller
        views: {}          // Arquivos específicos da view
    };
    let files = glob.sync(pattern);

    files.forEach((file) => {
        let relativePath = path.relative('./Src/js', file); // Caminho relativo a partir de Src/js
        let parts = relativePath.split(path.sep);           // Quebra o caminho em partes
        let fileName = path.basename(file, path.extname(file)); // Nome do arquivo sem extensão

        if (parts.length === 1) {
            // Arquivos gerais que devem ser carregados em todas as views
            entries.general[fileName] = path.resolve(__dirname, file);
        } else if (parts.length === 2) {
            // Arquivos gerais do controller
            let controllerName = parts[0];
            if (!entries.controllers[controllerName]) {
                entries.controllers[controllerName] = {};
            }
            entries.controllers[controllerName][fileName] = path.resolve(__dirname, file);
        } else if (parts.length >= 3) {
            // Arquivos específicos da view
            let controllerName = parts[0];
            let viewName = parts[1];
            if (!entries.views[controllerName]) {
                entries.views[controllerName] = {};
            }
            if (!entries.views[controllerName][viewName]) {
                entries.views[controllerName][viewName] = {};
            }
            entries.views[controllerName][viewName][fileName] = path.resolve(__dirname, file);
        }
    });
    return entries;
}
// /MAPEAMENTO DOS ARQUIVOS

const groupedEntries = groupEntriesByFolder('./Src/js/**/*.js');
const flatEntries = {
    ...groupedEntries.general,
    ...Object.keys(groupedEntries.controllers).reduce((acc, controller) => {
        Object.keys(groupedEntries.controllers[controller]).forEach((file) => {
            acc[`${controller}/${file}`] = groupedEntries.controllers[controller][file];
        });
        return acc;
    }, {}),
    ...Object.keys(groupedEntries.views).reduce((acc, controller) => {
        Object.keys(groupedEntries.views[controller]).forEach((view) => {
            Object.keys(groupedEntries.views[controller][view]).forEach((file) => {
                acc[`${controller}/${view}/${file}`] = groupedEntries.views[controller][view][file];
            });
        });
        return acc;
    }, {})
};

module.exports = {
    mode: 'production',
    entry: flatEntries,
    output: {
        filename: '[name].bundle.js?v=[contenthash]',
        path: path.resolve(__dirname, './wwwroot/dist/js/'),
    },
    devServer: {
        webSocketServer: false,
        static: {
            directory: path.join(__dirname, './wwwroot/dist'),
        },
        hot: false,
        port: 5000,
        open: false,
        devMiddleware: {
            writeToDisk: (filePath) => filePath.endsWith('.js') || filePath.endsWith('.cshtml'),
        },
        proxy: [
            {
                context: () => true,
                target: 'http://localhost:9000',
                changeOrigin: true,
                secure: false,
            },
        ],
    },
    plugins: [
        new CleanWebpackPlugin(),
        // Tags dos scripts gerais para todas as views
        new HtmlWebpackPlugin({
            inject: false,
            templateContent: ({ htmlWebpackPlugin }) => {
                const scripts = Object.keys(groupedEntries.general)
                    .map((fileName) => {
                        const jsPath = htmlWebpackPlugin.files.js.find((jsPath) =>
                            jsPath.includes(`/${fileName}.bundle.js`)
                        );

                        if (jsPath) {
                            return `<script src="${jsPath.replace('/wwwroot', '')}"></script>`;
                        } else {
                            return `<!-- Script não encontrado para ${fileName} -->`;
                        }
                    })
                    .join('\n');

                return scripts || `<!-- Nenhum script encontrado -->`;
            },
            filename: path.resolve(__dirname, './Views/Shared/Components/Webpack/index.cshtml')
        }),
        // Tags dos scripts gerais do controller
        ...webpackControllerConfig(groupedEntries.controllers),
        // Tags dos scripts exclusivos da view
        ...webpackViewConfig(groupedEntries.views),
    ],
};