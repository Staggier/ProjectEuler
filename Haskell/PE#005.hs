loopB :: Int -> Int -> Int -> Int
loopB n k i
  | (k^i < n)   = loopB n k (i + 1)
  | (otherwise) = k^(i - 1)

loopA :: [Int] -> Int -> Int -> Int 
loopA primes i n
  | (i == n)    = loopB n (primes !! i) 1
  | (otherwise) = loopB n (primes !! i) 1 * loopA primes (i + 1) n

main = do
  let primes = [ 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73]
  putStrLn $ show $ loopA primes 0 20