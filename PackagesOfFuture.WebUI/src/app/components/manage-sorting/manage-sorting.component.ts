import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SortingDto } from 'src/app/models/sorting';
import { SortingService } from 'src/app/services/sorting.service';
import { SortingModalComponent } from '../sorting-modal/sorting-modal.component';

@Component({
  selector: 'pof-manage-sorting',
  templateUrl: './manage-sorting.component.html',
  styleUrls: ['./manage-sorting.component.sass']
})
export class ManageSortingComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'name', 'street', 'houseNumber', 'postalCode', 'city', 'actions'];
  public sortings: SortingDto[];

  constructor(
    private sortingService: SortingService,
    private dialog: MatDialog) { }

  async ngOnInit() {
    await this.getSortings();
  }

  private async getSortings() {
    this.sortings = await this.sortingService.getSorting().toPromise();

    console.log("sortings", this.sortings);
  }

  public async editSorting(sorting: SortingDto) {
    const data = {
      editMode: true,
      sortingToEdit: sorting
    }

    const dialogRef = this.dialog.open(SortingModalComponent, {
      data: data
    });

    const result = await dialogRef.afterClosed().toPromise();

    if (result) {
      await this.sortingService.changeSortingDetails(result).toPromise();
      await this.getSortings();
    }
  }

  public async addSorting() {
    const data = {
      editMode: false,
      sortingToEdit: null
    }

    const dialogRef = this.dialog.open(SortingModalComponent, {
      data: data
    });

    const result = await dialogRef.afterClosed().toPromise();

    if (result) {
      await this.sortingService.addSorting(result).toPromise();
      await this.getSortings();
    }
  }
}
