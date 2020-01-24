;; The Problem can be found here: https://projecteuler.net/problem=57
(define (sqrtConvergents exp n d)
  (if (= exp 2)
      0
      (if (<= (+ (floor n) 0.5) n)
          (if (> (string-length (number->string (inexact->exact (+ (floor n) 1)))) (string-length (number->string d)))
              (+ 1 (sqrtConvergents (- exp 1) (/ (* (+ (+ (floor n) 1) d) (+ (floor n) 1)) d) (+ (inexact->exact (+ (floor n) 1)) d)))
                   (sqrtConvergents (- exp 1) (/ (* (+ (+ (floor n) 1) d) (+ (floor n) 1)) d) (+ (inexact->exact (+ (floor n) 1)) d)))
          (if (> (string-length (number->string (inexact->exact (floor n)))) (string-length (number->string d)))
              (+ 1 (sqrtConvergents (- exp 1) (/ (* (+ (floor n) d) (floor n)) d) (+ (inexact->exact (floor n)) d)))
                   (sqrtConvergents (- exp 1) (/ (* (+ (floor n) d) (floor n)) d) (+ (inexact->exact (floor n)) d))))))

(sqrtConvergents 1000 7 5)
;; Had to begin with the 2nd expansion otherwise all values afterward would be inaccurate from the cross multiplication