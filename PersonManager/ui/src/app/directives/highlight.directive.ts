import { Directive, ElementRef, HostListener, Input, Renderer2 } from '@angular/core';

@Directive({
  standalone: false,
  selector: '[appHighlight]',
})
export class HighlightDirective {

  @Input()
  color!: string;

  constructor(private el: ElementRef, private render: Renderer2) {

  }

  @HostListener('mouseenter') onMouseEnter() {
    this.highlight('yellow' );
  }
  @HostListener('mouseleave') onMouseLeave() {
    this.highlight('');
  }
  private highlight(color: string) {
    this.render.setStyle(this.el.nativeElement, 'backgroundColor', color);
  }
}
