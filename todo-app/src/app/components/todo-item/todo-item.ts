import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Todo } from '../../models/todo';

@Component({
  selector: 'app-todo-item',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './todo-item.html',
  styleUrl: './todo-item.scss',
})
export class TodoItem {
  @Input() todo!: Todo; 
  @Output() toggle = new EventEmitter<void>(); 
  @Output() remove = new EventEmitter<void>();

  onToggle() {
    this.toggle.emit();
  }

  onRemove() {
    this.remove.emit();
  }
}
