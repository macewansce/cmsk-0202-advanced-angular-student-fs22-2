import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'phone',
})
export class PhonePipe implements PipeTransform {
  transform(value: number): string {

    if (!value) return '';

    var cleaned = value.toString();
    var match = cleaned.match(/^(\d{3})(\d{3})(\d{4})$/);

    if (!match) return '';

    return `+1 (${match[1]}) ${match[2]}-${match[3]}`; 
  }
}