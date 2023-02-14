import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../services/products.service';

@Component({
  selector: 'app-add-form',
  templateUrl: './add-form.component.html',
  styleUrls: ['./add-form.component.css'],
})
export class AddFormComponent {
  constructor(private productService: ProductService) {}

  addForm: FormGroup;

  ngOnInit(): void {
    this.addForm = new FormGroup({
      codIdx: new FormControl('', [
        Validators.required,
        Validators.maxLength(20),
      ]),
      storeCode: new FormControl('', [
        Validators.required,
        Validators.maxLength(20),
      ]),
      name: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(150),
      ]),
      quantity: new FormControl(0, [Validators.required, Validators.min(0)]),
      unitPrice: new FormControl(0, [Validators.required, Validators.min(0)]),
    });
  }
  onSubmit() {
    this.productService.create(this.addForm.value);
  }
}
