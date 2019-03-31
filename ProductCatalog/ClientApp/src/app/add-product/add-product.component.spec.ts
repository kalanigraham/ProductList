import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AddProductComponent } from './add-product.component';


describe('AddProductComponent', () => {
  let component: AddProductComponent;
  let fixture: ComponentFixture<AddProductComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AddProductComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should display a name', async(() => {
    const nameText = fixture.nativeElement.querySelector('#name').textContent;
    expect(nameText).toContain('*Name:');
  }));

  it('should display a desc', async(() => {
    const nameText = fixture.nativeElement.querySelector('#desc').textContent;
    expect(nameText).toContain('Description:');
  }));

  it('should display a quantity', async(() => {
    const nameText = fixture.nativeElement.querySelector('#quantity').textContent;
    expect(nameText).toContain('*quantity:');
  }));
});
