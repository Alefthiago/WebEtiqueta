import * as path from 'path';
import HtmlWebpackPlugin from 'html-webpack-plugin';

export default function (controllers) {
    Object.keys(controllers).forEach((controllerName) => {
        console.log(`Controller: ${controllerName}`);
    });

    return Object.keys(controllers).map((controllerName) => {
        let outputPath = path.resolve('./Views/Shared/Components/Webpack/', controllerName, 'index.cshtml');

        return new HtmlWebpackPlugin({
            inject: false,
            templateContent: ({ htmlWebpackPlugin }) => {
                let scripts = Object.keys(controllers[controllerName])
                    .map((fileName) => {
                        let jsPath = htmlWebpackPlugin.files.js.find((jsPath) =>
                            jsPath.includes(`/${controllerName}/${fileName}.bundle.js`)
                        );
                        if (jsPath) {
                            return `<script src="${jsPath.replace('/wwwroot', '')}"></script>`;
                        } else {
                            return `<!-- Script não encontrado para ${controllerName}/${fileName} -->`;
                        }
                    })
                    .join('\n');

                return scripts || `<!-- Nenhum script encontrado -->`;
            },
            filename: outputPath,
        });
    });
}