import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DroneDto } from 'src/app/models/drone';
import { SortingDto } from 'src/app/models/sorting';
import { DroneService } from 'src/app/services/drone.service';
import { SortingService } from 'src/app/services/sorting.service';
import { AddDroneModalComponent } from '../add-drone-modal/add-drone-modal.component';
import { RemoveObjectModalComponent } from '../remove-object-modal/remove-object-modal.component';

@Component({
  selector: 'pof-manage-drones',
  templateUrl: './manage-drones.component.html',
  styleUrls: ['./manage-drones.component.sass']
})
export class ManageDronesComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'model', 'range', 'sortingName', 'actions'];
  public drones: DroneDto[];
  public sortings: SortingDto[];

  constructor(
    private droneService: DroneService,
    private sortingService: SortingService,
    private dialog: MatDialog) { }

  async ngOnInit() {
    await this.getDrones();
  }

  private async getDrones() {
    this.drones = await this.droneService.getDrones().toPromise();
    console.log(this.drones);
  }

  private async getSortings() {
    this.sortings = await this.sortingService.getSorting().toPromise();
  }

  public async removeDrone(drone: DroneDto) {
    const dialogRef = this.dialog.open(RemoveObjectModalComponent, {
      width: '200px',
    });

    const result = await dialogRef.afterClosed().toPromise();

    if (result) {
      await this.droneService.removeDrone(drone.id).toPromise();
      await this.getDrones();
    }
  }

  public async addDrone() {
    await this.getSortings();

    const data = {
      sortings: this.sortings,
      drone: null
    }

    const dialogRef = this.dialog.open(AddDroneModalComponent, {
      data: data
    });

    const result = await dialogRef.afterClosed().toPromise();

    if (result) {
      await this.droneService.registerDrone(result).toPromise();
      await this.getDrones();
    }
  }

  public async editDrone(drone: DroneDto) {
    await this.getSortings();

    const dialogRef = this.dialog.open(AddDroneModalComponent, {
      data: {
        sortings: this.sortings,
        drone: drone
      }
    });

    const result = await dialogRef.afterClosed().toPromise();

    if (result) {
      const editDrone = {
        droneId: drone.id,
        sortingId: result.sortingId,
        model: result.model,
        range: result.range
      }

      const sorting = this.sortings.find(x => x.name === drone.sortingName);

      await this.droneService.editDrone(editDrone).toPromise();
      await this.getDrones();
    }
  }
}
