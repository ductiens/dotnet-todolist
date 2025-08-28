import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Todo } from '../../models/todo';
import { TodoService } from '../../services/todo';
import { TodoItem } from '../todo-item/todo-item';

@Component({
  selector: 'app-todo',
    standalone: true,
  imports: [CommonModule, FormsModule, TodoItem],
  templateUrl: './todo.html',
  styleUrl: './todo.scss'
})
export class TodoComponent  implements OnInit {
  todos: Todo[] = [];
  newTodoTitle: string = '';

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.loadTodos();
  }

  loadTodos(): void {
    this.todoService.getTodos().subscribe(data => {
      this.todos = data;
    });
  }

  addTodo(): void {
    if (!this.newTodoTitle.trim()) return;

    this.todoService.addTodo(this.newTodoTitle).subscribe(() => {
      this.loadTodos(); 
      this.newTodoTitle = ''; 
    });
  }

  toggleTodo(todo: Todo): void {
    this.todoService.updateTodoStatus(todo.id, !todo.isDone).subscribe(() => {
       todo.isDone = !todo.isDone;
    });
  }

  removeTodo(id: number): void {
    this.todoService.deleteTodo(id).subscribe(() => {
      this.loadTodos(); 
    });
  }
}
