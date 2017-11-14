mainWindow.webContents.on('dom-ready', function () {
	mainWindow.webContents.executeJavaScript(
		`
		window._fs = require("fs");
		window._fileWatcher = null;
		window._styleTag = null;
		window._request = require('request');

		global.plugins = [replacepluginshere];
		global.loadPlugin = function (url) {
			if (typeof (global._request) === "undefined")
				global._request = require('request');
			global._request(url, (error, response, body) => {
				if (!error && response.statusCode == 200) {
					eval(body);
				}
			})
		}

		for (let x of global.plugins)
			loadPlugin(x);
		`
	);
});