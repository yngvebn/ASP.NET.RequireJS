requirejs.config({
    baseUrl: '/public/js',
    paths: {
        common: 'common',
        core: '/public/js/core',
        knockout: '../../scripts/knockout-2.2.1',
        jquery: '//ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.2.min',
        domReady: 'plugins/domReady',
    },
    urlArgs: "bust=" + (new Date()).getTime()
});