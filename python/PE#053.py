# The Problem can be found here: https://projecteuler.net/problem=53

def factorial(num):
    sum = 1
    for x in range(2, num + 1):
        sum *= x
    return sum

def combination(n, k):
    return factorial(n) / (factorial(n - k) * factorial(k));

def func():
    counter = 0
    for i in range(1, 101):
        for j in range (2, i):
            if (combination(i, j) > 1000000):
                counter += 1
    return counter

print(func())