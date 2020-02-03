#The problem can be found here: https://projecteuler.net/problem=24

def startingfn(n):
    i = 0
    t = 0
    while(factorial(t) < n):
        t += 1
    return t - 1

def f(n):
    product = 1
    for i in range(2, n + 1):
        product *= i
    return product

def highestfn(n, k):
    total = 0
    c = 0
    while (total < n):
        total += factorial(k)
        c += 1
    
    return [total - factorial(k), c - 1]

def lp(n):
    i = startingf(n)
    ans = ""

    dlst = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0]
    while f >= 0:
        tlst = lf(n, i)
        t = tlst[0]
        d = tlst[1] - 1
        
        ans += str(dlst[d])
        dlst.remove(dlst[d])

        n -= t
        i -= 1
        
    return ans

print(lp(1000000))

# Each digit can occur 9! times, the n! going down by one after each time a digit is removed.
# The max amount of times f(n) * i that can fit in n (minus 1) is the next digit.
# Ex: f(9) * 2 is the largest value that fits in 1,000,000 which makes the starting digit the 2nd value in the list of digits.