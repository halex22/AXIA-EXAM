import { Component } from '@angular/core';
import {FormControl, ReactiveFormsModule, FormGroup, Validators} from '@angular/forms'

@Component({
  selector: 'app-todo-create',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './todo-create.component.html',
  styleUrl: './todo-create.component.scss'
})
export class TodoCreateComponent {
  newTodoForm = new FormGroup({
    name: new FormControl('', {
      validators: []
    }),
    category: new FormControl('', {
      validators: []
    }
    )
  })
}
