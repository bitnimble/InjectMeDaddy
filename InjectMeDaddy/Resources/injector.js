mainWindow.webContents.on('dom-ready', function () {
  mainWindow.webContents.executeJavaScript(
    `
    global.jsPlugins = [replacejspluginshere];
    global.cssPlugins = [replacecsspluginshere];
    global.loadJsPlugin = function (url) {
      console.log('Loading JS plugin: ' + url);
      fetch(url)
        .then(resp => resp.text())
		.then(text => eval(text));
    }

    global.loadCssPlugin = function (url) {
      console.log('Loading CSS plugin: ' + url);
      const elem = document.createElement('link');
      elem.setAttribute('rel', 'stylesheet');
      elem.setAttribute('type', 'text/css');
      elem.setAttribute('href', url);
      document.querySelector('head').appendChild(elem);
    }

    for (let x of global.jsPlugins)
      loadJsPlugin(x);
    for (let x of global.cssPlugins)
      loadCssPlugin(x);
    `
  );
});
