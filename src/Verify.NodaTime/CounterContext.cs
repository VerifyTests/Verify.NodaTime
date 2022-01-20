﻿ using NodaTime;

 class CounterContext
 {
     static AsyncLocal<CounterContext?> local = new();

     ConcurrentDictionary<YearMonth, int> yearMonthCache = new();
     int currentYearMonth;

     public int Next(YearMonth input)
     {
         return yearMonthCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentYearMonth));
     }

     ConcurrentDictionary<ZonedDateTime, int> zonedDateTimeCache = new();
     int currentZonedDateTime;

     public int Next(ZonedDateTime input)
     {
         return zonedDateTimeCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentZonedDateTime));
     }

     ConcurrentDictionary<OffsetDateTime, int> offsetDateTimeCache = new();
     int currentOffsetDateTime;

     public int Next(OffsetDateTime input)
     {
         return offsetDateTimeCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentOffsetDateTime));
     }

     ConcurrentDictionary<OffsetDate, int> offsetDateCache = new();
     int currentOffsetDate;

     public int Next(OffsetDate input)
     {
         return offsetDateCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentOffsetDate));
     }

     ConcurrentDictionary<LocalDateTime, int> localDateTimeCache = new();
     int currentLocalDateTime;

     public int Next(LocalDateTime input)
     {
         return localDateTimeCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentLocalDateTime));
     }

     ConcurrentDictionary<LocalDate, int> localDateCache = new();
     int currentLocalDate;

     public int Next(LocalDate input)
     {
         return localDateCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentLocalDate));
     }

     ConcurrentDictionary<Instant, int> instantCache = new();
     int currentInstant;

     public int Next(Instant input)
     {
         return instantCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentInstant));
     }

     ConcurrentDictionary<AnnualDate, int> annualDateCache = new();
     int currentAnnualDate;

     public int Next(AnnualDate input)
     {
         return annualDateCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentAnnualDate));
     }

     public static void Init()
     {
         VerifierSettings.OnVerify(Start, Stop);
     }

     public static CounterContext Current
     {
         get
         {
             var context = local.Value;
             if (context == null)
             {
                 throw new("No current context");
             }

             return context;
         }
     }

     static void Start()
     {
         local.Value = new();
     }

     static void Stop()
     {
         local.Value = null;
     }
 }