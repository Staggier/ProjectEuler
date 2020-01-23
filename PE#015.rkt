;;The Problem can be found here: https://projecteuler.net/problem=15

(define (factorial n)
  (if (= n 1)
      1
      (* n (factorial (- n 1)))))

(define (Combination n k)
  (/ (factorial n) (* (factorial k) (factorial k))))

(display (Combination 40 20))
;; There will be 40 steps total with 20 in each direction.