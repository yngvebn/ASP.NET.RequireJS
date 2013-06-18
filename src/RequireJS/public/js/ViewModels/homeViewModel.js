/// <reference path="../common/capitalizer.js" />

define(['knockout', 'common/capitalizer', 'bindingHandlers/isActive'], function (ko, capitalizer) {
    return function homeViewModel() {
        var self = this;
        self.title = ko.observable('hello world');
        self.body = ko.observable(capitalizer.capitalize('Lorem Ipsum'));
        self.active = ko.observable(false);
        self.activate = function() {
            self.active(!self.active());
        };
    };
});