import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { map } from 'rxjs/operators';
import { Task } from '../_models/task';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'users');
  }

  getUser(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + 'users/' + id);
  }

  updateUser(id: number, user: User) {
    return this.http.put(this.baseUrl + 'users/' + id, user);
  }

  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.baseUrl + 'clienttask');
  }
  addTask(task: Task) {
    return this.http.post(this.baseUrl + 'clienttask/', task);
  }
  deleteTask(id: number) {
    return this.http.delete(this.baseUrl + 'clienttask/' + id);
  }
}
