// Importações
import HtmlWebpackPlugin from 'html-webpack-plugin';
import { CleanWebpackPlugin } from 'clean-webpack-plugin';
import * as glob from 'glob';
import * as path from 'path';
import webpackControllerConfig from './webpack.controller.config.js';
import webpackViewConfig from './webpack.view.config.js';

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
            entries.general[fileName] = path.resolve(file);
        } else if (parts.length === 2) {
            // Arquivos gerais do controller
            let controllerName = parts[0];
            if (!entries.controllers[controllerName]) {
                entries.controllers[controllerName] = {};
            }
            entries.controllers[controllerName][fileName] = path.resolve(file);
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
            entries.views[controllerName][viewName][fileName] = path.resolve(file);
        }
    });
    return entries;
}

// Mapeamento dos arquivos e transformação em entradas para Webpack
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

// Exportação da configuração do Webpack
export default {
    mode: 'production',
    entry: flatEntries,
    output: {
        filename: '[name].bundle.js?v=[contenthash]',
        path: path.resolve('./wwwroot/dist/js/'),
    },
    devServer: {
        webSocketServer: false,
        static: {
            directory: path.join('./wwwroot/dist'),
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
                let scripts = Object.keys(groupedEntries.general)
                    .map((fileName) => {
                        let jsPath = htmlWebpackPlugin.files.js.find((jsPath) =>
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
            filename: path.resolve('./Views/Shared/Components/Webpack/index.cshtml')
        }),
        // Tags dos scripts gerais do controller
        ...webpackControllerConfig(groupedEntries.controllers),
        // Tags dos scripts exclusivos da view
        ...webpackViewConfig(groupedEntries.views),
    ],
};