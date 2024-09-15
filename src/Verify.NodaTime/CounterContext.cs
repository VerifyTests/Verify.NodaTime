  class CounterContext
  {
      static AsyncLocal<CounterContext?> local = new();

      ConcurrentDictionary<YearMonth, int> yearMonthCache = [];
      int currentYearMonth;

      public int Next(YearMonth input) =>
          yearMonthCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentYearMonth));

      ConcurrentDictionary<ZonedDateTime, int> zonedDateTimeCache = [];
      int currentZonedDateTime;

      public int Next(ZonedDateTime input) =>
          zonedDateTimeCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentZonedDateTime));

      ConcurrentDictionary<OffsetDateTime, int> offsetDateTimeCache = [];
      int currentOffsetDateTime;

      public int Next(OffsetDateTime input) =>
          offsetDateTimeCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentOffsetDateTime));

      ConcurrentDictionary<OffsetDate, int> offsetDateCache = [];
      int currentOffsetDate;

      public int Next(OffsetDate input) =>
          offsetDateCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentOffsetDate));

      ConcurrentDictionary<LocalDateTime, int> localDateTimeCache = [];
      int currentLocalDateTime;

      public int Next(LocalDateTime input) =>
          localDateTimeCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentLocalDateTime));

      ConcurrentDictionary<LocalDate, int> localDateCache = [];
      int currentLocalDate;

      public int Next(LocalDate input) =>
          localDateCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentLocalDate));

      ConcurrentDictionary<Instant, int> instantCache = [];
      int currentInstant;

      public int Next(Instant input) =>
          instantCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentInstant));

      ConcurrentDictionary<AnnualDate, int> annualDateCache = [];
      int currentAnnualDate;

      public int Next(AnnualDate input) =>
          annualDateCache.GetOrAdd(input, _ => Interlocked.Increment(ref currentAnnualDate));

      public static void Init() =>
          VerifierSettings.OnVerify(Start, Stop);

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

      static void Start() =>
          local.Value = new();

      static void Stop() =>
          local.Value = null;
  }