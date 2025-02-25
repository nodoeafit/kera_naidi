import { Component, AfterViewInit, ViewChild, NgZone } from '@angular/core';
import { GoogleMap, MapMarker, MapInfoWindow } from '@angular/google-maps';
import { CommonModule, NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-mapa-ubicacion',
  templateUrl: './mapa-ubicacion.component.html',
  styles: [`
    .map-container {
      width: 100%;
      height: 90vh;
    }
  `],
  standalone: true,
  imports: [MapMarker, MapInfoWindow, CommonModule, NgFor, GoogleMap] // ✅ Importamos MapMarker y MapInfoWindow
 // ✅ Importamos MapMarker y MapInfoWindow
 // ✅ Importamos MapMarker y MapInfoWindow
})
export class MapaUbicacionComponent implements AfterViewInit {
  addMarker(event: google.maps.MapMouseEvent) {
    if (event.latLng) {
      this.markers.push({
        lat: event.latLng.lat(),
        lng: event.latLng.lng(),
        title: 'Nuevo Marcador',
        icon: 'https://maps.google.com/mapfiles/kml/pal3/icon21.png'
      });
    }
  }
  
  moveMap(event: google.maps.MapMouseEvent) {
    if (event.latLng) {
      this.center = {
        lat: event.latLng.lat(),
        lng: event.latLng.lng()
      };
    }
  }
  
  @ViewChild(GoogleMap) mapComponent!: GoogleMap;
  @ViewChild(MapInfoWindow) infoWindow!: MapInfoWindow; // ✅ Referencia a la ventana emergente
  selectedMarker: any = null;
  
  center: google.maps.LatLngLiteral = { lat: 4.65838, lng: -74.09368 };
  zoom = 15;
  minZoomToShowMarkers = 15;

  markers = [
    { lat: 4.6575, lng: -74.0935, title: "Stand de comida 1", icon: "https://maps.google.com/mapfiles/kml/pal3/icon21.png" },
    { lat: 4.6576, lng: -74.0936, title: "Stand de comida 2", icon: "https://maps.google.com/mapfiles/kml/pal3/icon21.png" },
    { lat: 4.6577, lng: -74.0937, title: "Stand de comida 3", icon: "https://maps.google.com/mapfiles/kml/pal3/icon21.png" },
    { lat: 4.6576, lng: -74.0938, title: "Stand de comida 4", icon: "https://maps.google.com/mapfiles/kml/pal3/icon21.png" },
    { lat: 4.6575, lng: -74.0939, title: "Stand de comida 5", icon: "https://maps.google.com/mapfiles/kml/pal3/icon21.png" },

    { lat: 4.6580, lng: -74.0934, title: "Entrada Principal", icon: "https://maps.google.com/mapfiles/kml/pal3/icon31.png" },
    { lat: 4.6579, lng: -74.0935, title: "Salida", icon: "https://maps.google.com/mapfiles/kml/pal3/icon48.png" },
    { lat: 4.6578, lng: -74.0933, title: "Entrada Secundaria", icon: "https://maps.google.com/mapfiles/kml/pal3/icon31.png" },

    { lat: 4.6577, lng: -74.0936, title: "Escenario 1", icon: "https://maps.google.com/mapfiles/kml/pal3/icon49.png" },
    { lat: 4.6578, lng: -74.0937, title: "Escenario 2", icon: "https://maps.google.com/mapfiles/kml/pal3/icon49.png" },
    { lat: 4.6579, lng: -74.0938, title: "Escenario 3", icon: "https://maps.google.com/mapfiles/kml/pal3/icon49.png" },

    { lat: 4.6576, lng: -74.0936, title: "Baños 1", icon: "https://maps.google.com/mapfiles/kml/pal3/icon20.png" },
    { lat: 4.6575, lng: -74.0937, title: "Baños 2", icon: "https://maps.google.com/mapfiles/kml/pal3/icon20.png" },

    { lat: 4.6577, lng: -74.0934, title: "Punto Ecológico 1", icon: "https://maps.google.com/mapfiles/kml/pal3/icon30.png" },
    { lat: 4.6578, lng: -74.0935, title: "Punto Ecológico 2", icon: "https://maps.google.com/mapfiles/kml/pal3/icon30.png" }
];
  constructor(private ngZone: NgZone) {}

  ngAfterViewInit(): void {
    if (this.mapComponent.googleMap) {
      this.mapComponent.googleMap.addListener('zoom_changed', () => {
        this.ngZone.run(() => {
          this.zoom = this.mapComponent.googleMap!.getZoom() || 0;
        });
      });
    }
  }

  visibleMarkers() {
    return this.zoom >= this.minZoomToShowMarkers ? this.markers : [];
  }

  openInfoWindow(marker: any, markerRef: MapMarker) {
    this.selectedMarker = marker;
    this.infoWindow.open(markerRef); // ✅ Muestra la ventana en el marcador seleccionado
  }
}