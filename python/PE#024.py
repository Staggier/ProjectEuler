#The problem can be found here: https://projecteuler.net/problem=24

def sf(n):
    i, t = 0, 0
    while f(t) < n:
        t += 1
    return t - 1

def f(n):
    product = 1
    for i in range(2, n + 1):
        product *= i
    return product

def lf(n, k):
    total = 0
    c = 0
    while total < n:
        total += f(k)
        c += 1
    
    return [total - f(k), c - 1]

def lp(n):
    f = sf(n)
    ans = ""

    dlst = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0]
    while f >= 0:
        tlst = lf(n, f)
        t, d = tlst[0], tlst[1] - 1
        
        n -= t
        ans += str(dlst[d])
        dlst.remove(dlst[d])
        f -= 1
        
    return ans

print(lp(1000000))

# Each digit can occur 9! times, the n! going down by one after each time a digit is removed.
# The max amount of times f(n) * i that can fit in n (minus 1) is the next digit.
# Ex: f(9) * 2 is the largest value that fits in 1,000,000 which makes the starting digit the 2nd value in the list of digits.
