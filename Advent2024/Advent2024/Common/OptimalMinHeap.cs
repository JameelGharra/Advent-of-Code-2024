using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2024.Common {
    public class OptimalMinHeap {
        private List<int> heap;

        private void HeapifyDown(int index) {
            int smallest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < heap.Count && heap[left] < heap[smallest]) {
                smallest = left;
            }
            if (right < heap.Count && heap[right] < heap[smallest]) {
                smallest = right;
            }
            if (smallest != index) {
                (heap[smallest], heap[index]) = (heap[index], heap[smallest]);
                HeapifyDown(smallest);
            }
        }
        public int ExtractMin() {
            if (heap.Count == 0) {
                throw new InvalidOperationException("Heap is empty");
            }
            int min = heap[0];
            heap[0] = heap[^1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return min;
        }
        private void BuildHeap() {
            for (int i = heap.Count / 2 - 1; i >= 0; --i) {
                HeapifyDown(i);
            }
        }

        public OptimalMinHeap(IEnumerable<int> elements) {
            heap = new List<int>(elements);
            BuildHeap();
        }

    }
}
