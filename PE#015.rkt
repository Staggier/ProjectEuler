(define (factorial n)
  (if (= n 1)
      1
      (* n (factorial (- n 1)))))

(define (C n k)
  (/ (factorial n) (* (factorial k) (factorial k))))

(display (C 40 20))