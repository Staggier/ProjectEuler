;; The Problem can be found here: projecteuler.net/problem=57

(define (sqrtConvergents num n d)
  (if (= num 0)
      0
      (if (> (string-length (number->string n)) (string-length (number->string d)))
          (+ 1 (sqrtConvergents (- num 1) (round (/ (* n (+ n d)) d)) (+ n d)))
          (sqrtConvergents (- num 1) (round (/ (* n (+ n d)) d)) (+ n d)))))

(sqrtConvergents 998 7 5)