import { AbstractControl } from "@angular/forms"

export default class CustomValidators {
    static emailValidationFn(control: AbstractControl){
        let validEmailPattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/
        return validEmailPattern.test(control.get('email')?.value) === true ? null: { notmatched: true}
    }
}
