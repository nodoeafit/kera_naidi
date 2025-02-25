import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MapaUbicacionComponent } from './mapa-ubicacion.component';
import { GoogleMapsModule } from '@angular/google-maps';

describe('MapaUbicacionComponent', () => {
  let component: MapaUbicacionComponent;
  let fixture: ComponentFixture<MapaUbicacionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GoogleMapsModule],
      declarations: [MapaUbicacionComponent]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MapaUbicacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('Debe crear el componente', () => {
    expect(component).toBeTruthy();
  });

  it('Debe iniciar centrado en Parque El Tunal, Bogotá', () => {
    expect(component.center).toEqual({ lat: 4.57619, lng: -74.12704 });
  });

  it('Debe actualizar el centro del mapa al hacer clic', () => {
    const nuevaUbicacion = { lat: 4.60, lng: -74.12 }; 
    component.moveMap({ latLng: { toJSON: () => nuevaUbicacion } } as google.maps.MapMouseEvent);
    expect(component.center).toEqual(nuevaUbicacion);
  });

  it('Debe agregar un marcador al hacer clic', () => {
    const initialMarkers = component.markers.length;
    const eventMock = { latLng: { lat: () => 4.57619, lng: () => -74.12704 } } as google.maps.MapMouseEvent;

    component.addMarker(eventMock);
    expect(component.markers.length).toBe(initialMarkers + 1);
  });
});