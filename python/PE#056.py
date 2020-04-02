# The Problem can be found here: https://projecteuler.net/problem=56

def digitalSum(x ,n):
    s = str(x ** n)
    ans = 0
    
    for i in range(0, len(s)):
        ans += int(s[i])

    return ans

def MaxDigitalSum():
    a = 90
    b = 90
    
    largest = 1
    while a < 100:
        if b > 100:
            b = 90
            a += 1

        test = digitalSum(a, b)
        if largest < test:
            largest = test
        b += 1

    return largest

print(MaxDigitalSum())