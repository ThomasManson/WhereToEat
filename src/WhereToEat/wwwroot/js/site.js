"use strict";

let map;
let currentInfoWindow;
let markers;
let currentLocation;
let markerCluster;

function showMapWithCurrentLocation() {
    var lat = 37.7577909;
    var long = -122.4232633;
    showMap(lat, long);
    $("input#lat").val(lat);
    $("input#long").val(long);
}

function showMap(lat, long) {

    var myLocation = new google.maps.LatLng(lat, long);
    var mapOptions = {
        center: myLocation,
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    map = new google.maps.Map(document.getElementById("map"), mapOptions);
    var mylocationMarker = new google.maps.Marker({
        position: myLocation,
        title: "My location",
        icon: "/images/icon23.png"
    });
    mylocationMarker.setMap(map);

    google.maps.event.addListener(map, 'bounds_changed', function () {
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
            if (markers) {
                markers.forEach(marker => {
                    marker.setMap(null);
                    marker = null;
                });
                markerCluster.clearMarkers();
            }
            markers = data.map((truck, i) => {
                var contentString = '<div id="content">' +
                    '<div id="siteNotice"></div>' +
                    '<h6 id="thirdHeading" class="thirdHeading">' + truck.applicant + '</h6>' +
                    '<div id="bodyContent">' +
                    '<b>Address:</b> ' + truck.address + '<br/>' +
                    '<b>Food:</b> ' + truck.fooditems + '<br/>' +
                    '<b>Days and times:</b> ' + ((truck.dayshours !== null) ? truck.fooditems : 'Unknown') + '<br/>' +
                    '</div>' +
                    '</div>';
                var infowindow = new google.maps.InfoWindow({
                    content: contentString,
                });
                var marker = new google.maps.Marker({
                    position: new google.maps.LatLng(truck.latitude, truck.longitude),
                    title: truck.applicant,
                });
                marker.addListener('click', () => {
                    if (currentInfoWindow) {
                        currentInfoWindow.close();
                    }
                    currentInfoWindow = infowindow;
                    infowindow.open(map, marker);

                });
                return marker;
            });

            markerCluster = new MarkerClusterer(map, markers);
        };
        options.error = function () {

        }
        $.ajax(options);

    });
}

function showFoodTrucks() {
    var currentBounds = map.getBounds();
}
