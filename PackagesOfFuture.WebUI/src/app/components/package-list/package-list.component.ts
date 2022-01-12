import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { AuthorizationService } from 'src/app/auth/authorization.service';
import { PackageDto } from 'src/app/models/packages';
import { PackageStatus, PaymentStatus, RoleEnumType } from 'src/app/models/enums';
import { PackagesService } from 'src/app/services/packages.service';
import { PackageDetailsModalComponent } from '../package-details-modal/package-details-modal.component';
import { PackagePaymentModalComponent } from '../package-payment-modal/package-payment-modal.component';

@Component({
  selector: 'pof-package-list',
  templateUrl: './package-list.component.html',
  styleUrls: ['./package-list.component.sass']
})
export class PackageListComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: MatTableDataSource<PackageDto>;
  displayedColumns: string[] = ['deliveryDate', 'packageStatus', 'deliveryAddress', 
    'receiverAddress', 'paymentAmount', 'paymentStatus', 'details'];

  private currentUserId: number;
  private currentUserRole: string;

  public isAdmin: boolean = false;
  public packageList: PackageDto[];

  constructor(
    private packageService: PackagesService,
    private authorizationService: AuthorizationService,
    private _liveAnnouncer: LiveAnnouncer,
    public dialog: MatDialog) { }

  async ngOnInit() {
    await this.getCurrentUserData();
    await this.setPackages();

  }

  private async setPackages() {
    await this.getPackages();
    this.paginator._intl.itemsPerPageLabel="Paczek na stronie";
    this.dataSource = new MatTableDataSource<PackageDto>(this.packageList);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private getCurrentUserData() {
    this.currentUserId = this.authorizationService.currentUserId();
    this.currentUserRole = this.authorizationService.role();

    if (this.currentUserRole === RoleEnumType.Administrator) {
      this.isAdmin = true;
    } else {
      this.displayedColumns.push('pay')
    }
  }

  private async getPackages() {
    if (this.isAdmin) {
      this.packageList = await this.packageService.getPackagesByAdmin().toPromise();
    } else {
      this.packageList = await this.packageService.getPackagesByUserId(this.currentUserId).toPromise();
    }

    console.log(this.packageList)
  }

    /** Announce the change in sort state for assistive technology. */
    announceSortChange(sortState: Sort) {
      // This example uses English messages. If your application supports
      // multiple language, you would internationalize these strings.
      // Furthermore, you can customize the message to add additional
      // details about the values being sorted.
      if (sortState.direction) {
        this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
      } else {
        this._liveAnnouncer.announce('Sorting cleared');
      }
    }

    public getDetails(pack: PackageDto){
      this.dialog.open(PackageDetailsModalComponent, {
        data: pack
      });
    }

    public async payForPackage(pack: PackageDto){
      const dialogRef = this.dialog.open(PackagePaymentModalComponent, {
        width: '250px',
      });

      const result = await dialogRef.afterClosed().toPromise();

      if (result) {
        const changeStatusPaymentDto = {
          paymentId: pack.payment.id,
          paymentStatus: result
        }

        await this.packageService.changePaymentStatus(changeStatusPaymentDto).toPromise();
        await this.setPackages();
      }
    }

    public getPackageStatus(status: number): string {
      return PackageStatus[status];
    }

    public getPaymentStatus(status: number): string {
      return PaymentStatus[status];
    }

    public canPayForPackage(status: number): boolean {
      if (status === PaymentStatus.InProgress) {
        return true;
      }
      return false;
    }
}
