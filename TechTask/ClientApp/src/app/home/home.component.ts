import { Component, Inject } from '@angular/core';
import { GoogleMapsAPIWrapper, AgmMap, LatLngBounds, LatLngLiteral, LatLng } from '@agm/core';
import { GpsPointsService } from '../services/gpspoints.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  constructor(
    private gpspointsservice: GpsPointsService) { }

  // google maps zoom level
  zoom: number = 8;
  renderZoom: number = 0;

  // initial center position for the map
  lat: number = 40.762428283691406;
  lng: number = -73.971176147460938;

  fitBounds: LatLngBounds;

  clickedMarker(label: string, index: number) {
    console.log(`clicked the marker: ${index}`)
  }

  zoomChange(zoom: number) {
    this.zoom = zoom;
    console.log(`zoom changed to: ${zoom}`)
  }

  boundsChange(data: LatLngBounds) {
    console.log(`boundsChange to NE ${data.getNorthEast().lng()},${data.getNorthEast().lat()}
                to SW ${data.getSouthWest().lng()}, ${data.getSouthWest().lat()}`)
      this.setBoundPoints(data);
  }

  centerChanged(data: LatLngLiteral) {
    console.log(`centerChanged to: ${data}`)
  }

  idle() {
    console.log(`idle  to: ${this}`)
  }

  mapReady(map: AgmMap) {
    this.setInitialPoints();
    this.renderZoom = this.zoom;
    console.log(`mapReady `)
  }

  markers: GpsPoint[];

  private async setInitialPoints() {
    this.markers = await this.gpspointsservice.GetInitialPoints();
  }

  private async setBoundPoints(newBounds: LatLngBounds) {
    
    var result =  await this.gpspointsservice.GetBoundPoints(
      this.zoom.toString(),
      newBounds.getSouthWest().lat().toString(),
      newBounds.getNorthEast().lat().toString(),
      newBounds.getSouthWest().lng().toString(),
      newBounds.getNorthEast().lng().toString());
    if (result.length > 0) {
      this.markers = result;
      console.log(`markers length = ${this.markers.length}`);
      this.renderZoom = this.zoom;
    }
  }
}

interface GpsPoint {
  lat: number;
  lng: number;
  count: number;
}

