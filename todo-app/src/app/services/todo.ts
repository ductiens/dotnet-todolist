import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ApiResponse, Todo } from '../models/todo';
@Injectable({
  providedIn: 'root'
})
export class TodoService  {
  private apiUrl = 'http://localhost:5044/api/todo';
  constructor(private http: HttpClient) { }

  getTodos(): Observable<Todo[]> {
    return this.http.get<ApiResponse<Todo[]>>(this.apiUrl)
      .pipe(map(response => response.data));
  }

  addTodo(title: string): Observable<Todo> {
    const newTodo = { title, isDone: false };
    return this.http.post<Todo>(this.apiUrl, newTodo);
  }

  updateTodoStatus(id: number, isDone: boolean): Observable<any> {
    return this.http.patch(`${this.apiUrl}/${id}`, { isDone });
  }

  deleteTodo(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
