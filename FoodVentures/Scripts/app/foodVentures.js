var foodVentures = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}
};

foodVentures.moduleOptions = {
    APPNAME: "foodVenturesApp"
    , extraModuleDependencies: []
    , runners: []
    , page: foodVentures.page//we need this object here for later use
};

foodVentures.layout.startUp = function () {

    console.debug("foodVentures.layout.startUp");

    //this does a null check on sabio.page.startUp
    if (foodVentures.page.startUp) {
        console.debug("foodVentures.page.startUp");
        foodVentures.page.startUp();
    }
};

foodVentures.APPNAME = "foodVenturesApp";//legacy
$(document).ready(foodVentures.layout.startUp);