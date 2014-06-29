Shorty
======

Performant URL Shortener built with Redis and AngularJS.


##Early Benchmarks##

Shorty uses Redis, an advanced in-memory key-value store that is highly scalable. Similar uses SQL Server.

**Shorty**:

    Percentage of the requests served within a certain time (ms)
      50%   4225
      66%   4313
      75%   4508
      80%   4660
      90%   4972
      95%   5128
      98%   5187
      99%   5207
     100%   5275 (longest request)
**Similar**: 

    Percentage of the requests served within a certain time (ms)
      50%  21962
      66%  22282
      75%  22361
      80%  22430
      90%  22824
      95%  22933
      98%  23225
      99%  23313
     100%  23535 (longest request)

