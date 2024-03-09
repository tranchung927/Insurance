// config-overrides.js
const path = require('path');
module.exports = function override(config) {
  config.resolve = {
    ...config.resolve,
    alias: {
      '@src': path.resolve(__dirname, 'src'),
      '@axios': path.resolve(__dirname, 'src/Config/axiosConfig.js'), 
      '@image-path': path.resolve(__dirname, 'src/Config/imagePath.js'),
      '@Style': path.resolve(__dirname, 'src/App.css'),
      '@HeaderLayout': path.resolve(__dirname, 'src/Component/header.js'),
      '@FooterLayout': path.resolve(__dirname, 'src/Component/footer.js'),
      '@DataContext': path.resolve(__dirname, 'src//Context/data-context.js'),
    },
  };

  return config;
};
