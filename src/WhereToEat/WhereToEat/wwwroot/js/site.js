// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";

let map;

function showMapWithCurrentLocation(position) {
    var lat = position.coords.latitude;
    var long = position.coords.longitude;
    var myLocation = new google.maps.LatLng(lat, long);
    var mapOptions = {
        center: myLocation,
        zoom: 12,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById("map"), mapOptions);
    var mylocationMarker = new google.maps.Marker({
        position: myLocation,
        title: "My location"
    });
    mylocationMarker.setMap(map);

    google.maps.event.addListener(map, 'bounds_changed', function ()
    {
        var bounds = new google.maps.LatLngBounds();
        bounds = map.getBounds();
        var northEast = bounds.getNorthEast();
        var southWest = bounds.getSouthWest();
        var northWest = new google.maps.LatLng(northEast.lat(), southWest.lng());
        var southEast = new google.maps.LatLng(southWest.lat(), northEast.lng());

        var options = {};
        options.url = "/api/FoodTruck";
        options.data = { northwestLatitude: northWest.lat(), northwestLongitude: northWest.lng(), southeastLatitude: southEast.lat(), southeastLongitude: southEast.lng() };
        options.type = "GET";
        options.dataType = "json";
        options.success = function (data) {

        };
        options.error = function () {

        }
        $.ajax(options);

    });
}

function showFoodTrucks() {
    var currentBounds = map.getBounds();
}
