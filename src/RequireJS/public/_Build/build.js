

({
	appDir: '../js',
	baseUrl: './',
	mainConfigFile: '../js/core.js',
	dir: '../release',
	modules: [
			{
			name: 'views/home/about'
		},
			{
			name: 'views/home/index'
		},
			{
			name: 'views/user/login'
		},
		],
	onBuildRead: function (moduleName, path, contents) {
        if (moduleName === "core") {
            return contents.replace("/public/js","/public/release")
        }
        return contents;
    },
})




