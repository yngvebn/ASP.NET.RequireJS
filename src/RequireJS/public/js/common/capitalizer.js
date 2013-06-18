define(function () {
    function capitalize(string) {
        console.log('capitalizer called');
        return string.toUpperCase();
    }
    return {
        capitalize: capitalize
    }
});