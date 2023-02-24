#The problem can be found here: https://projecteuler.net/problem=24

# Gets largest factorial(i) < n and returns i
def sf(n: int) -> int:
    i = 0
    while f(i) < n:
        i += 1
    return i - 1

# Factorial
def f(n: int) -> int:
    product = 1
    for i in range(2, n + 1):
        product *= i
    return product

# Gets the largest f(k) * i < n and returns the sum and i
def lf(n: int, k: int) -> list[int, int]: 
    total = 0
    i = 0
    while total < n:
        total += f(k)
        i += 1
    
    return [total - f(k), i - 2]

# Gets the n-th lexicographic permutation of digits 0-9
def lp(n: int) -> int:
    f = sf(n)
    ans = ""

    #list of digits to be removed
    dlst = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0]
    
    while f >= 0:
        t, d = lf(n, f)
        
        n -= t
        ans += str(dlst[d])
        dlst.remove(dlst[d])
        f -= 1
        
    return ans

print(lp(10 ** 6))

# Each digit can occur 9! times, the n! going down by one after each time a digit is removed.
# The max amount of times f(n) * i that can fit in n (minus 1) is the next digit.
# Ex: f(9) * 2 is the largest value that fits in 1,000,000 which makes the starting digit the 2nd value in the list of digits.
