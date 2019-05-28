import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '../../../node_modules/@angular/router';
import { Task } from '../_models/task';
import { NgForm, FormGroup } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  addTaskToggle: boolean;
  users: User[];
  tasks: Task[];
  newTask: Task;
  @ViewChild('taskForm') editForm: NgForm;
  taskForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  city: any;
  name: any;
  filterType = 'name';
  filteredUsers: User[];
  filteredTasks: Task[];
  selectedUser: User;
  constructor(private userService: UserService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.users = data['users'];
    });
    this.selectedUser = this.users[0];
    this.filteredUsers = this.users;
    this.route.data.subscribe(data => {
      this.tasks = data['tasks'];
    });
    this.filteredTasks = this.tasks;
    this.newTask = this.tasks[0];
  }

  // pageChanged(event: any): void {
  //   this.loadUsers();
  //   this.filterTasks();
  //   this.filterUsers();
  // }

  loadUsers() {
    this.userService.getUsers()
      .subscribe((res: User[]) => {
        this.users = res;
    }, error => {
      this.alertify.error(error);
    });
  }

  selectUser(event, id: number) {
    this.selectedUser = this.users.find(x => x.id === id);
    this.filterTasks();
  }

  loadTasks() {
    this.userService.getTasks()
      .subscribe((res: Task[]) => {
        this.tasks = res;
    }, error => {
      this.alertify.error(error);
    });
  }

  filterTasks() {
    if (this.selectedUser.id) {
      this.filteredTasks = this.tasks.filter(t => t.clientId === this.selectedUser.id);
    } else {
      this.filteredTasks = this.tasks;
    }
  }

  filterUsers() {
    if (this.city && this.filterType === 'city') {
      this.filteredUsers = this.users.filter(u => u.city === this.city);
      this.selectedUser = this.filteredUsers[0];
    } else if (this.name && this.filterType === 'name') {
      this.filteredUsers = this.users.filter(u => u.lastName === this.name);
      this.selectedUser = this.filteredUsers[0];
    } else {
      this.filteredTasks = this.tasks;
    }
  }

  resetFilters() {
    this.selectedUser = this.users[0];
    this.filteredUsers = this.users;
    this.filteredTasks = this.tasks;
    this.filterType = 'city';
    this.city = '';
    this.name = '';
  }

  addTask() {
    this.newTask.clientId = this.selectedUser.id;
    this.userService.addTask(this.newTask).subscribe(next => {
      this.alertify.success('Task added successfully');
      this.ngOnInit();
    }, error => {
      this.alertify.error(error);
    });
  }

  deleteTask(event, id: number) {
    this.userService.deleteTask(id).subscribe(next => {
      this.alertify.success('Task deleted successfully');
      this.ngOnInit();
    }, error => {
      this.alertify.error(error);
    });
  }

  toggleAddTask() {
    this.addTaskToggle = !this.addTaskToggle;
  }
}
