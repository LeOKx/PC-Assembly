import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'power'
})
export class PowerPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return value + " ⚡";
  }

}
