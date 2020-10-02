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
}
