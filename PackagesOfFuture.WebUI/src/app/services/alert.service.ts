import { Injectable } from '@angular/core';
import { NotificationService } from "@progress/kendo-angular-notification"

@Injectable({
    providedIn: 'root'
})
export class AlertService {

  constructor(private notificationService: NotificationService) {}

  public showSuccess(content: string): void {
      this.notificationService.show({
          content: content,
          hideAfter: 1000,
          position: { horizontal: "center", vertical: "top"},
          animation: { type: "fade", duration: 400 },
          type: { style: "success", icon: true}
      });
  }

  public test() {
      this.notificationService.show({
          content: "ELO",
          type: { style: "success", icon: true }
      })
  }

}
