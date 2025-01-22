import * as path from 'path';
import HtmlWebpackPlugin from 'html-webpack-plugin';

export default function (views) {
    return Object.keys(views).flatMap((controllerName) => {
        return Object.keys(views[controllerName]).map((viewName) => {
            let outputPath = path.resolve('./Views/Shared/Components/Webpack/', controllerName, viewName, 'index.cshtml');

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