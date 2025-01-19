const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = function (views) {
    return Object.keys(views).flatMap((controllerName) => {
        return Object.keys(views[controllerName]).map((viewName) => {
            let outputPath = path.resolve(__dirname, `./Views/Shared/Components/Webpack/${controllerName}/${viewName}/index.cshtml`);

            return new HtmlWebpackPlugin({
                inject: false,
                templateContent: ({ htmlWebpackPlugin }) => {
                    let scripts = Object.keys(views[controllerName][viewName])
                        .map((fileName) => {
                            let jsPath = htmlWebpackPlugin.files.js.find((jsPath) =>
                                jsPath.includes(`/${controllerName}/${viewName}/${fileName}.bundle.js`)
                            );
                            console.log(`View caminho ${jsPath}`);
                            if (jsPath) {
                                return `<script src="${jsPath.replace('/wwwroot', '')}"></script>`;
                            } else {
                                return `<!-- Script não encontrado para ${controllerName}/${viewName}/${fileName} -->`;
                            }
                        })
                        .join('\n');

                    return scripts || `<!-- Nenhum script encontrado -->`;
                },
                filename: outputPath,
            });
        });
    });
}