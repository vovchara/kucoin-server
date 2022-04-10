using KukoinServer.Model;

namespace KukoinServer.Services
{
    public class KucoinProviderService
    {
        private readonly KucoinMessagingService messagingService;
        private readonly OrderBookService orderBookService;

        public KucoinProviderService(KucoinMessagingService messagingService, OrderBookService orderBookService)
        {
            this.messagingService = messagingService;
            this.orderBookService = orderBookService;
        }

        internal async Task<StatusDTO> GetInfo(string pairId)
        {
            if (!messagingService.isConnected(pairId))
            {
                var isSucess = await messagingService.ConnectToSocket(pairId);
                if (!isSucess)
                {
                    // log error can not connect
                    return null;
                }
            }
            var lastMessage = await messagingService.GetLastMessage();
            if (lastMessage == null)
            {
                // log error message not found
                return null;
            }
            var orderBook = await orderBookService.GetOrderBook(pairId);
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

        private MessageModel DropOldSequences(MessageModel lastMessage, int sequence)
        {
            throw new NotImplementedException();
        }

        private MessageModel DropZeroPrices(MessageModel filteredSeqMessage)
        {
            throw new NotImplementedException();
        }

        private OrderBookModel FilterEmptyPairsFromOredBook(OrderBookModel orderBook, MessageModel filteredZeroPriceMessage)
        {
            throw new NotImplementedException();
        }

        private OrderBookModel UpdatePrizesInOrderBook(OrderBookModel orderBookWithoutEmptyPairs, MessageModel filteredZeroPriceMessage)
        {
            throw new NotImplementedException();
        }
    }
}
