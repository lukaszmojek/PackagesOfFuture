import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/users';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'pof-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.sass']
})
export class UsersListComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'firstName', 'lastName', 'email', 'type', 'actions'];
  public users: User[] = []

  public get areUsersLoading(): boolean {
    return !this.users.length
  }

  constructor(private usersService: UserService) { }

  ngOnInit(): void {
    this.loadUsers()
  }

  public removeUser(userId: number): void {
    this.usersService.unregisterUser(userId).subscribe(_ => {
      this.users = []
      this.loadUsers()
    })
  }

  private loadUsers(): void {
    this.usersService.getAllUsers().subscribe(users => {
      this.users = users
    })
  }
}
