(function () {
    "use strict";

    angular.module('foodVenturesApp')
        .directive('googleplace', Googleplace);


    function Googleplace() {

        return (
            {
                require: 'ngModel'
                , scope: {
                    ngModel: '=',
                    details: '=?'
                }
                , link: link
            }
        );
        function link(scope, element, attrs, model) {
            var options = {
                types: [],
                componentRestrictions: {}
            };

            scope.gPlace = new google.maps.places.Autocomplete(element[0], options);

            google.maps.event.addListener(scope.gPlace, 'place_changed', function () {
                var geoComponents = scope.gPlace.getPlace();
                var latitude = geoComponents.geometry.location.lat();
                var longitude = geoComponents.geometry.location.lng();
                var addressComponents = geoComponents.address_components;

                addressComponents = addressComponents.filter(function (component) {
                    switch (component.types[0]) {
                        case "locality": // city
                            return true;
                        case "administrative_area_level_1": // state
                            return true;
                        case "country": // country
                            return true;
                        default:
                            return false;
                    }
                }).map(function (obj) {
                    return obj.long_name;
                });
                //Construct objet using addressComponents
                addressComponents.push(latitude, longitude);
                var location = {
                    name: geoComponents.name,
                    city: addressComponents[0],
                    state: addressComponents[1],
                    country: addressComponents[2],
                    latitude: addressComponents[3],
                    longitude: addressComponents[4]
                };

                scope.$apply(function () {
                    scope.details = location;
                    model.$setViewValue(element.val());
                });
            });
        };


    }

})();