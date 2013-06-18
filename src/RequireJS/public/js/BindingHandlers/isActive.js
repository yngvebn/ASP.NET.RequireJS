define(['knockout'], function(ko) {
    ko.bindingHandlers.isActive = {
        update: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            if (value) {
                element.className = 'active';
            } else {
                element.className = '';
            }
        }
    };
});