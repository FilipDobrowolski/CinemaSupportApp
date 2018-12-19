// Basically there are three types of directives in angular2 according to documentation.

// Component is also a type of directive with template,styles and logic part which is most famous type of directive 
// Structural directives like *ngFor 
// Attribute directives
//atribute directive  CSS attribute selector https://angular.io/guide/attribute-directives
import { Directive, ElementRef, HostListener, Input } from "@angular/core";

@Directive({
    selector: '[appHighlight]'
})
export class HighlightDirective {


    constructor(private el:ElementRef) {
    }

    @Input() defaultColor: string;
 
    @Input('appHighlight') highlightColor: string;

    @HostListener('mouseenter') onMouseEnter() {
        this.highlight('#ffe6e6');
      }
      
      @HostListener('mouseleave') onMouseLeave() {
        this.highlight(null);
      }
      
      private highlight(color: string) {
        this.el.nativeElement.style.backgroundColor = color;
      }
}