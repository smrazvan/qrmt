import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ProductService } from '../services/products.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
})
export class EditComponent {
  constructor(
    private productService: ProductService,
    private route: ActivatedRoute
  ) {}

  updateForm: FormGroup;
  codIdx = this.route.snapshot.paramMap.get('codIdx');

  ngOnInit(): void {
    if (this.codIdx) {
      this.productService.getById(this.codIdx).subscribe((product) => {
        this.updateForm = new FormGroup({
          codIdx: new FormControl({ value: product.codIdx, disabled: true }, [
            Validators.required,
            Validators.maxLength(20),
          ]),
          storeCode: new FormControl(product.storeCode, [
            Validators.required,
            Validators.maxLength(20),
          ]),
          name: new FormControl(product.name, [
            Validators.required,
            Validators.minLength(3),
            Validators.maxLength(150),
          ]),
          registrationDate: new FormControl(product.registrationDate, [
            Validators.required,
          ]),
          quantity: new FormControl(product.quantity, [
            Validators.required,
            Validators.min(0),
          ]),
          unitPrice: new FormControl(product.unitPrice, [
            Validators.required,
            Validators.min(0),
          ]),
        });
      });
    }
  }

  onSubmit() {
    console.log(this.updateForm.value);
    this.productService.edit({ ...this.updateForm.value, codIdx: this.codIdx });
  }
}
