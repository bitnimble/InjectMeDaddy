mainWindow.webContents.on('dom-ready', function () {
	mainWindow.webContents.executeJavaScript(
		`
		window._fs = require('fs');
		window._fileWatcher = null;
		window._styleTag = null;
		window._request = require('request');

		global.jsPlugins = [replacejspluginshere];
		global.cssPlugins = [replacecsspluginshere];
		global.loadJsPlugin = function (url) {
			if (typeof (global._request) === 'undefined')
				global._request = require('request');
			global._request(url, (error, response, body) => {
				if (!error && response.statusCode == 200) {
					eval(body);
				}
			})
		}

		global.loadCssPlugin = function (url) {
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