using KukoinServer.Model;

namespace KukoinServer.Services
{
    public class KucoinProviderService
    {
        private readonly KucoinMessagingService _messagingService;
        private readonly OrderBookService _orderBookService;
        private readonly MessagesStorage _messagesStorage;

        public KucoinProviderService(KucoinMessagingService messagingService, OrderBookService orderBookService, MessagesStorage messagesStorage)
        {
            _messagingService = messagingService;
            _orderBookService = orderBookService;
            _messagesStorage = messagesStorage;
        }

        internal async Task<StatusDTO> GetInfo(string pairId)
        {
            if (!_messagingService.isConnectedAndReady(pairId))
            {
                var isSucess = await _messagingService.ConnectToSocket(pairId);
                if (!isSucess)
                {
                    // log error can not connect
                    return null;
                }
            }
            var lastMessage = _messagesStorage.GetMessages();
            if (lastMessage == null)
            {
                // log error message not found
                return null;
            }
            var orderBook = await _orderBookService.GetOrderBook(pairId);
            if(orderBook == null)
            {
                // log error order book not found
                return null;
            }
            var filteredSeqMessage = DropOldSequences(lastMessage, orderBook.Sequence);
            var filteredZeroPriceMessage = DropZeroPrices(filteredSeqMessage);
            var orderBookWithoutEmptyPairs = FilterEmptyPairsFromOredBook(orderBook, filteredZeroPriceMessage);
            var orderBookWithUpdatedPrizes = UpdatePrizesInOrderBook(orderBookWithoutEmptyPairs, filteredZeroPriceMessage);

            var statusDTO = CreateResultDTO(orderBookWithUpdatedPrizes);
            return statusDTO;
        }

        private StatusDTO CreateResultDTO(OrderBookModel orderBookWithUpdatedPrizes)
        {
            throw new NotImplementedException();
        }

        private AsksBidsDTO DropOldSequences(AsksBidsDTO lastMessage, int sequence)
        {
            throw new NotImplementedException();
        }

        private AsksBidsDTO DropZeroPrices(AsksBidsDTO filteredSeqMessage)
        {
            throw new NotImplementedException();
        }

        private OrderBookModel FilterEmptyPairsFromOredBook(OrderBookModel orderBook, AsksBidsDTO filteredZeroPriceMessage)
        {
            throw new NotImplementedException();
        }

        private OrderBookModel UpdatePrizesInOrderBook(OrderBookModel orderBookWithoutEmptyPairs, AsksBidsDTO filteredZeroPriceMessage)
        {
            throw new NotImplementedException();
        }
    }
}
