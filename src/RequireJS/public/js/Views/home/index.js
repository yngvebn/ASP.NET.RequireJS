require(['knockout', 'viewmodels/homeViewModel', 'domReady!'], function (ko, homeViewModel) {
    console.log('dom ready');
    ko.applyBindings(new homeViewModel());
});